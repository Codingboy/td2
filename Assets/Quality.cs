public class Quality
{
	private float quality;
	private float factor;
	public Quality()
	{
		quality = 0f;//[0;100)
		factor = 10000f;//the bigger the better
	}
	public void adjustFactor(float f)//f>1 means better
	{
		factor *= f;
	}
	public void reduceQuality()
	{
		float missing = 100 - quality;
		missing *= missing;
		missing /= factor;//ql=1->0.98 ql=10->0.81 ql=20->0.64 ql=30->0.49 ql=40->0.36 ql=50->0.25 ql=60->0.16 ql=70->0.09 ql=80->0.04 ql=90->0.01
		setQuality(quality-missing);
	}
	public void increaseQuality()
	{
		float missing = 100 - quality;
		missing *= missing;
		missing /= factor;//ql=1->0.98 ql=10->0.81 ql=20->0.64 ql=30->0.49 ql=40->0.36 ql=50->0.25 ql=60->0.16 ql=70->0.09 ql=80->0.04 ql=90->0.01
		setQuality(quality+missing);
	}
	public bool isDestroyed()
	{
		return quality <= 0;
	}
	public void setQuality(float ql)
	{
		if (ql > 100)
		{
			quality = 100;
		}
		else if (ql < 0)
		{
			quality = 0;
		}
		else
		{
			quality = ql;
		}
	}
	public float getQuality()
	{
		return quality;
	}
}

