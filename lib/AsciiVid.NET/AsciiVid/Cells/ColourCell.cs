﻿using System.Drawing;
using System.Text;

namespace AsciiVid.Cells
{
	public class ColourCell
	{
		/// <summary>
		///     The character for this cell
		/// </summary>
		public char Character;

		/// <summary>
		///     The red colour channel of the cell
		/// </summary>
		public byte RedChannel;

		/// <summary>
		///     The green colour channel of the cell
		/// </summary>
		public byte GreenChannel;

		/// <summary>
		///     The blue colour channel of the cell
		/// </summary>
		public byte BlueChannel;


		public ColourCell(char character, byte redChannel, byte greenChannel, byte blueChannel)
		{
			Character    = character;
			RedChannel   = redChannel;
			GreenChannel = greenChannel;
			BlueChannel  = blueChannel;
		}

		public ColourCell(byte[] binary)
		{
			var parsed = Parse(binary);
			Character    = parsed.Character;
			RedChannel   = parsed.RedChannel;
			GreenChannel = parsed.GreenChannel;
			BlueChannel  = parsed.BlueChannel;
		}

		/// <summary>
		///     The corresponding Sytem.Drawing.Color for the cell
		/// </summary>
		public Color Colour => Color.FromArgb(RedChannel, GreenChannel, BlueChannel);

		public byte[] GetBinary() => new[]
			{Encoding.ASCII.GetBytes(new[] {Character})[0], RedChannel, GreenChannel, BlueChannel};

		public static ColourCell Parse(byte[] binary)
		{
			return new ColourCell(Encoding.ASCII.GetChars(new[] {binary[0]})[0], // Character is first byte
			                      binary[1],                                     // Next three bytes are colour
			                      binary[2],
			                      binary[3]);
		}
	}
}