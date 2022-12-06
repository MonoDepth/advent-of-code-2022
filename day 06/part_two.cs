using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

string packet = File.ReadAllText("input_one.txt");
Console.WriteLine(FindPacketStart(packet, 14));

static int FindPacketStart(string packet, int markerLength)
{
	List<char> sequence = new();
	for (int i = 0; i < packet.Length; i++)
	{
		sequence.Add(packet[i]);

		if (sequence.Count == markerLength)
		{
			if (sequence.Distinct().Count() == markerLength)
				return i + 1;

			sequence.RemoveAt(0);
		}
	}
	return -1;
}
