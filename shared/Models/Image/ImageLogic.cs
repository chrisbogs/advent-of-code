using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCodeShared.Models.Image
{
    public class ImageLogic
    {
        public static void PrintImage(List<char> result, int width)
        {
            for (var i = 0; i < result.Count; i++)
            {
                Console.Write(result[i] == '0' ? ' ' : '*');
                if (i != 0 && i % width == 0)
                {
                    Console.Write(Environment.NewLine);
                }
            }
        }

        //Break up the string into chunks of widthxheight chunks
        public static List<string> SeparateIntoLayers(string message, int layerSize)
        {
            var layers = new List<string>();
            for (var i = 0; i < message.Length; i += layerSize)
            {
                layers.Add(message.Substring(i, layerSize));
            }
            return layers;
        }

        private enum PixelColour
        {
            Black = 0,
            White = 1,
            Transparent = 2
        }

        public static List<char> ConvertToImage(List<string> layers, int layerSize)
        {
            //The image is rendered by stacking the layers and aligning the pixels with the same positions in each layer.
            //The digits indicate the color of the corresponding pixel: 0 is black, 1 is white, and 2 is transparent.
            //The layers are rendered with the first layer in front and the last layer in back.
            //So, if a given position has a transparent pixel in the first and second layers,
            //a black pixel in the third layer,
            //and a white pixel in the fourth layer,
            //the final image would have a black pixel at that position.
            var finalMessage = layers[0].ToList();

            var otherLayers = layers.Skip(1);

            for (var i = 0; i < layerSize; i++)
            {
                foreach (var layer in otherLayers)
                {
                    if ((PixelColour)int.Parse(finalMessage[i].ToString()) != PixelColour.Transparent)
                    {
                        break;
                    }
                    // If we can see through to the next layer, continue
                    if ((PixelColour)int.Parse(layer[i].ToString()) != PixelColour.Transparent)
                    {
                        finalMessage[i] = layer[i];
                    }
                }
            }

            return finalMessage.Where(x => x != 2).ToList();
        }
    }
}
