using PoryGuard.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

namespace PoryGuard.Controller
{
    class AnaliseDeCapturas
    {
        private int R = 0, G = 0, B = 0, Raux = 0, Gaux = 0, Baux = 0;
        private double luminanciaRelativa, luminanciaRelativaAux, vermelhoCritico, vermelhoCriticoAux;
        private double[] luminanciaMedia, vermelhoCriticoMedio;
        private bool liberado = false;
        private int frameRate;
        private float proporcao;
        private int limiarVermelho = 20; // Limiar de desvio de vermelho para considerar um quadrante como "flash"
        private int variacao = 30; // Valor de tolerância na variação de intensidade luminosa
        private int limiarLuminancia = 20; // Limiar de desvio de luminancia para considerar um quadrante como "flash"
        private Bitmap[] bitmaps;
        int subdivisoes = 30; // Número de subdivisões da maior dimensão para a análise
        private Censura censura;

        private const string configPath = "ConfiguraçãoPersistente.json";
        public int flashMinimo { get; set; }
        public int flashMaximo { get; set; }
        public int luminosidadeTela { get; set; }
        public int opacidadeCensura { get; set; }
        public AnaliseDeCapturas(int frameRate, float proporcao)
        {
            censura = new Censura();

            this.frameRate = frameRate;
            bitmaps = new Bitmap[frameRate];
            this.proporcao = proporcao;
            luminanciaMedia = new double[frameRate];
            vermelhoCriticoMedio = new double[frameRate];
            CarregarConfiguracoes();
        }

        private void CarregarConfiguracoes()
        {
            if (!File.Exists(configPath))
                return;
            var json = File.ReadAllText(configPath);
            var config = JsonSerializer.Deserialize<ConfiguracaoPersistente>(json);
            flashMinimo = config.FlashMinimo;
            flashMaximo = config.FlashMaximo;
            variacao = config.LuminosidadeTela;
            limiarLuminancia = config.LuminosidadeQuadrante;
            subdivisoes = config.Quadrantes;
            limiarVermelho = config.VermelhoCritico;
            opacidadeCensura = (int)(config.Opacidade*255f)/100;   
        }

        public void InserirFrame(Bitmap bitmap, int contador)
        {
            if (contador == frameRate - 1)
                liberado = true;
            bitmaps[contador] = new Bitmap(bitmap);
            Color cores = CalcularMediaRGB(bitmaps[contador]);
            luminanciaMedia[contador] = 0.2126 * cores.R + 0.7152 * cores.G + 0.0722 * cores.B;
            vermelhoCriticoMedio[contador] = (cores.R - cores.G - cores.B) * 320 / 255f;
            if (contador % 15 == 0)
                AnalisarFrames(contador);
        }

        public void AnalisarFrames(int contador)
        {
            if (!liberado)
                return;
            try
            {
                censura.ClearRectangles();

                int contadorAux = contador;
                int subAltura = (int)Math.Ceiling((double)(bitmaps[contador].Height * subdivisoes) / bitmaps[contador].Width);
                double pixelsPorAltura = (double)bitmaps[contador].Height / subAltura;
                double pixelsPorLargura = (double)bitmaps[contador].Width / subdivisoes;
                bool[,] quadrantes = new bool[subdivisoes, subAltura];

                for (int i = 0; i < subdivisoes; i++)
                {
                    for (int j = 0; j < subAltura; j++)
                    {
                        int flashes = 0;
                        for (int aux = 0; aux < frameRate; aux++)
                        {
                            if (--contadorAux == -1)
                                contadorAux = frameRate - 1;

                            if (Math.Abs(luminanciaMedia[contador] - luminanciaMedia[contadorAux]) >= limiarLuminancia ||
                                Math.Abs(vermelhoCriticoMedio[contador] - vermelhoCriticoMedio[contadorAux]) >= limiarVermelho)
                            {
                                int pixelX = Math.Min((int)((i + 0.5) * pixelsPorLargura), bitmaps[contador].Width - 1);
                                int pixelY = Math.Min((int)((j + 0.5) * pixelsPorAltura), bitmaps[contador].Height - 1);

                                R = bitmaps[contador].GetPixel(pixelX, pixelY).R;
                                G = bitmaps[contador].GetPixel(pixelX, pixelY).G;
                                B = bitmaps[contador].GetPixel(pixelX, pixelY).B;
                                vermelhoCritico = (R - G - B) * 320 / 255f;
                                if (vermelhoCritico < 0)
                                    vermelhoCritico = 0;
                                luminanciaRelativa = 0.2126 * R + 0.7152 * G + 0.0722 * B;

                                Raux = bitmaps[contadorAux].GetPixel(pixelX, pixelY).R;
                                Gaux = bitmaps[contadorAux].GetPixel(pixelX, pixelY).G;
                                Baux = bitmaps[contadorAux].GetPixel(pixelX, pixelY).B;
                                vermelhoCriticoAux = (Raux - Gaux - Baux) * 320 / 255f;
                                if (vermelhoCriticoAux < 0)
                                    vermelhoCriticoAux = 0;
                                luminanciaRelativaAux = 0.2126 * Raux + 0.7152 * Gaux + 0.0722 * Baux;

                                if (Math.Abs(luminanciaRelativa - luminanciaRelativaAux) >= variacao ||
                                    Math.Abs(vermelhoCritico - vermelhoCriticoAux) >= limiarVermelho)
                                {
                                    flashes++;
                                }
                            }
                            if (--contador == -1)
                                contador = frameRate - 1;
                        }

                        quadrantes[i, j] = flashes >= 6;
                    }
                }

                DetectarBlocosDeFlashes(quadrantes, pixelsPorLargura, pixelsPorAltura);
                censura.Redesenhar();
            }
            catch (NullReferenceException ex)
            { }
        }

        private void DetectarBlocosDeFlashes(bool[,] quadrantes, double pixelsPorLargura, double pixelsPorAltura)
        {
            int altura = quadrantes.GetLength(1);
            int largura = quadrantes.GetLength(0);

            // Matriz para controlar quais quadrantes já foram processados
            bool[,] processados = new bool[largura, altura];

            // Processar cada região de quadrantes conectados
            for (int i = 0; i < largura; i++)
            {
                for (int j = 0; j < altura; j++)
                {
                    if (quadrantes[i, j] && !processados[i, j])
                    {
                        // Encontrar todos os quadrantes conectados nesta região
                        List<Point> regiao = EncontrarRegiaoConectada(quadrantes, processados, i, j, largura, altura);

                        // Criar retângulos sem sobreposições para esta região
                        CriarRetangulosSemSobreposicao(regiao, pixelsPorLargura, pixelsPorAltura);
                    }
                }
            }
        }
        private List<Point> EncontrarRegiaoConectada(bool[,] quadrantes, bool[,] processados,
    int startI, int startJ, int largura, int altura)
        {
            List<Point> regiao = new List<Point>();
            Queue<Point> fila = new Queue<Point>();

            fila.Enqueue(new Point(startI, startJ));
            processados[startI, startJ] = true;

            // Direções: cima, baixo, esquerda, direita
            int[] dx = { 0, 0, -1, 1 };
            int[] dy = { -1, 1, 0, 0 };

            while (fila.Count > 0)
            {
                Point atual = fila.Dequeue();
                regiao.Add(atual);

                // Verificar vizinhos adjacentes
                for (int dir = 0; dir < 4; dir++)
                {
                    int newX = atual.X + dx[dir];
                    int newY = atual.Y + dy[dir];

                    if (newX >= 0 && newX < largura && newY >= 0 && newY < altura &&
                        !processados[newX, newY] && quadrantes[newX, newY])
                    {
                        processados[newX, newY] = true;
                        fila.Enqueue(new Point(newX, newY));
                    }
                }
            }

            return regiao;
        }
        private void CriarRetangulosSemSobreposicao(List<Point> regiao, double pixelsPorLargura, double pixelsPorAltura)
        {
            if (regiao.Count == 0) return;

            // Converter lista de pontos em matriz booleana para facilitar processamento
            int minX = regiao.Min(p => p.X);
            int maxX = regiao.Max(p => p.X);
            int minY = regiao.Min(p => p.Y);
            int maxY = regiao.Max(p => p.Y);

            int largura = maxX - minX + 1;
            int altura = maxY - minY + 1;

            bool[,] grid = new bool[largura, altura];

            // Marcar pontos no grid local
            foreach (var ponto in regiao)
            {
                grid[ponto.X - minX, ponto.Y - minY] = true;
            }

            // Criar retângulos conectando horizontal E vertical
            bool[,] processados = new bool[largura, altura];

            for (int j = 0; j < altura; j++) // Por linha
            {
                for (int i = 0; i < largura; i++) // Por coluna
                {
                    if (grid[i, j] && !processados[i, j])
                    {
                        // Encontrar o maior retângulo possível a partir deste ponto
                        Rectangle rect = EncontrarMaiorRetanguloNaRegiao(grid, processados, i, j, largura, altura,
                            minX, minY, pixelsPorLargura, pixelsPorAltura);

                        if (rect.Width > 0 && rect.Height > 0)
                        {
                            censura.AddRectangle(rect.X, rect.Y, rect.Width, rect.Height,
                                Color.FromArgb(opacidadeCensura, 0, 0, 0));
                        }
                    }
                }
            }
        }
        private Rectangle EncontrarMaiorRetanguloNaRegiao(bool[,] grid, bool[,] processados, int startI, int startJ,
    int largura, int altura, int offsetX, int offsetY, double pixelsPorLargura, double pixelsPorAltura)
        {
            if (!grid[startI, startJ] || processados[startI, startJ])
                return Rectangle.Empty;

            // Primeiro, encontrar a largura máxima na linha atual
            int maxLargura = 0;
            for (int i = startI; i < largura && grid[i, startJ] && !processados[i, startJ]; i++)
            {
                maxLargura++;
            }

            if (maxLargura == 0) return Rectangle.Empty;

            // Encontrar quantas linhas consecutivas têm essa largura completa disponível
            int maxAltura = 0;
            for (int j = startJ; j < altura; j++)
            {
                bool linhaCompleta = true;

                // Verificar se toda a largura está disponível nesta linha
                for (int i = startI; i < startI + maxLargura; i++)
                {
                    if (i >= largura || !grid[i, j] || processados[i, j])
                    {
                        linhaCompleta = false;
                        break;
                    }
                }

                if (linhaCompleta)
                {
                    maxAltura++;
                }
                else
                {
                    break; // Parar na primeira linha incompleta
                }
            }

            if (maxAltura == 0) return Rectangle.Empty;

            // Marcar toda a área do retângulo como processada
            for (int i = startI; i < startI + maxLargura; i++)
            {
                for (int j = startJ; j < startJ + maxAltura; j++)
                {
                    processados[i, j] = true;
                }
            }

            // Converter coordenadas locais para coordenadas globais de pixels
            int globalX = offsetX + startI;
            int globalY = offsetY + startJ;

            int pixelX = (int)(globalX * pixelsPorLargura);
            int pixelY = (int)(globalY * pixelsPorAltura);
            int pixelWidth = (int)(maxLargura * pixelsPorLargura);
            int pixelHeight = (int)(maxAltura * pixelsPorAltura);

            return new Rectangle(pixelX, pixelY, pixelWidth, pixelHeight);
        }

        private Color CalcularMediaRGB(Bitmap imagem)
        {
            using (var reduzido = new Bitmap(1, 1))
            using (var g = Graphics.FromImage(reduzido))
            {
                g.InterpolationMode = InterpolationMode.High;
                g.CompositingQuality = CompositingQuality.HighSpeed;
                g.SmoothingMode = SmoothingMode.None;
                g.PixelOffsetMode = PixelOffsetMode.HighSpeed;

                var colorMatrix = new ColorMatrix(new float[][]
                {
                    new float[] {1, 0, 0, 0, 0},
                    new float[] {0, 1, 0, 0, 0},
                    new float[] {0, 0, 1, 0, 0},
                    new float[] {0, 0, 0, 1, 0},
                    new float[] {0, 0, 0, 0, 1}
                });

                var imageAttributes = new ImageAttributes();
                imageAttributes.SetColorMatrix(colorMatrix);

                g.DrawImage(imagem, new Rectangle(0, 0, 1, 1), 0, 0, imagem.Width, imagem.Height, GraphicsUnit.Pixel, imageAttributes);

                return reduzido.GetPixel(0, 0);
            }
        }

        public void PararAnalise()
        {
            for (int i = 0; i < bitmaps.Length; i++)
            {
                try
                {
                    bitmaps[i].Dispose();
                    bitmaps[i] = null;
                }
                catch (NullReferenceException ex)
                { }
            }
            try
            {
                censura?.EncerraCensura();
                censura = null;
            }
            catch (NullReferenceException ex)
            { }
        }
    }
}