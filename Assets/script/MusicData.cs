using UnityEngine;
using System.Collections;

public class MusicData {

	public long tick;
	public int value;
	public bool isCreated;

	public MusicData( long tick, int value ) {
		this.tick = tick;
		this.value = value;
		this.isCreated = false;
	}
}