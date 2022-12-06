/*
--- Part Two ---

Your device's communication system is correctly detecting packets, but still isn't working. It looks like it also needs to look for messages.

A start-of-message marker is just like a start-of-packet marker, except it consists of 14 distinct characters rather than 4.

Here are the first positions of start-of-message markers for all of the above examples:

    mjqjpqmgbljsphdztnvjfqwrcgsmlb: first marker after character 19
    bvwbjplbgvbhsrlpgdmjqwftvncz: first marker after character 23
    nppdvjthqldpwncqszvftbrmjlhg: first marker after character 23
    nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg: first marker after character 29
    zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw: first marker after character 26

How many characters need to be processed before the first start-of-message marker is detected?
*/

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
