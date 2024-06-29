using SFML.Graphics;
using SFML.System;

namespace SFML_Game
{
    internal class Tilemap
    {
        List<Tile> _tiles;

        public Tilemap(string texturePath, string filePath, Vector2i tileSize, int tilesPerRow)
        {
            _tiles = new List<Tile>();

            List<List<int>> indexMap = new List<List<int>>();

            string csvRawData = File.ReadAllText(filePath);

            csvRawData = csvRawData.Replace("\r", "");

            string[] rows = csvRawData.Split('\n');


            //Convertimos el texto del archivo en numeros  que podemos usar. 
            for (int i = 0; i < rows.Length - 1; i++) // Ordenamos los char que recibimos dentro nuestra lista de indices.
            {
                indexMap.Add(new List<int>());
                string[] indexes = rows[i].Split(',');
                for (int j = 0; j < indexes.Length; j++)
                {
                    indexMap[i].Add(Convert.ToInt32(indexes[j]));
                }
            }

            //Usamos los indicies para armar nuestro tilemap

            for (int i = 0; i < indexMap.Count; i++)
            {
                for (int j = 0; j < indexMap[i].Count; j++)
                {
                    IntRect tileArea= new IntRect();

                    tileArea.Height = tileSize.Y;
                    tileArea.Width = tileSize.X;

                    //               numero en la columna * alto del tile
                    tileArea.Top = (indexMap[i][j] / tilesPerRow) * tileSize.Y;
                    //               numero en la file * ancho del tile
                    tileArea.Left = (indexMap[i][j] % tilesPerRow) * tileSize.X;

                    Texture tileMap = new Texture(texturePath,tileArea);
                    Sprite sprite = new Sprite(tileMap);

                    _tiles.Add(new Tile(sprite, new Vector2f(tileArea.Size.Y * j, tileArea.Size.X * i)));
                }
            }
        }

        public void Draw(RenderWindow window)
        {
            for (int i = 0; i < _tiles.Count; i++)
            {
                _tiles[i].Draw(window);
            }
        }
    }

}
