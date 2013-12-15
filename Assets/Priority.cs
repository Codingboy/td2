public enum Priority
{
	Ignore,
	Idle,//only handled if nothing else to do
	VeryLow,
	Low,
	Normal,//normal orders
	High,//finish last order and continue with this
	VeryHigh,//finish last high order and continue with this
	ASAP//immediately drop other orders
}

