using System;

public class myVector3
{
	public float x,y,z;
	public float magnitude;
	public myVector3 normalized;
	float sqrMagnitude;

	readonly public static myVector3 back = new myVector3 (0,0,-1);
	readonly public static myVector3 down = new myVector3 (0,-1,0);
	readonly public static myVector3 forward = new myVector3 (0,0,1);
	readonly public static myVector3 left = new myVector3 (-1,0,0);
	readonly public static myVector3 one = new myVector3 (1,1,1);
	readonly public static myVector3 right = new myVector3 (1,0,0);
	readonly public static myVector3 up = new myVector3 (0,1,0);
	readonly public static myVector3 zero = new myVector3 (0,0,0);

	public myVector3 (float x,float y,float z)
	{
		this.x = x;
		this.y = y;
		this.z = z;
		sqrMagnitude = x * x + y * y + z * z;
		magnitude = (float)Math.Sqrt ((double)sqrMagnitude);
		//normalized
		if (Math.Abs (sqrMagnitude - 1.0) < 0.0000001f) {
			normalized = this;
		} else {
			normalized = new myVector3 (x/magnitude,y/magnitude,z/magnitude);
		}
	}

	public void Set(float new_x,float new_y,float new_z){
		this.x = new_x;
		this.y = new_y;
		this.z = new_z;
		sqrMagnitude = x * x + y * y + z * z;
		magnitude = (float)Math.Sqrt ((double)sqrMagnitude);
		//normalized
		if (Math.Abs (sqrMagnitude - 1.0) < 0.0000001f) {
			normalized = this;
		} else {
			normalized = new myVector3 (x/magnitude,y/magnitude,z/magnitude);
		}
	}

	public string ToString(){
		string s = "("+x.ToString("f1")+","+y.ToString("f1")+","+z.ToString("f1")+")";
		return s;
	}

	public float Distance(myVector3 a,myVector3 b){
		return (a - b).magnitude;
	}

	public myVector3 Lerp(myVector3 start,myVector3 end,float t){
		if (t >= 1)
			t = 1.0f;
		if (t <= 0)
			t = 0.0f;
		return start * (1 - t) + end * t;
	}

	public float Dot(myVector3 a,myVector3 b){
		return a.x * b.x + a.y * b.y + a.z * b.z;
	}

	public static myVector3 operator+ (myVector3 a,myVector3 b){
		return new myVector3 (a.x+b.x,a.y+b.y,a.z+b.z);
	}
	public static myVector3 operator- (myVector3 a,myVector3 b){
		return new myVector3 (a.x-b.x,a.y-b.y,a.z-b.z);
	}
	public static myVector3 operator* (myVector3 a,float k){
		return new myVector3 (a.x*k,a.y*k,a.z*k);
	}
	public static myVector3 operator* (float k,myVector3 a){
		return new myVector3 (a.x*k,a.y*k,a.z*k);
	}
	public static bool operator== (myVector3 a,myVector3 b){
		myVector3 c = a - b;
		bool x = Math.Abs (c.x) < 0.00000001f; 
		bool y = Math.Abs (c.y) < 0.00000001f; 
		bool z = Math.Abs (c.z) < 0.00000001f; 
		return x && y && z;
	}
	public static bool operator!= (myVector3 a,myVector3 b){
		myVector3 c = a - b;
		bool x = Math.Abs (c.x) < 0.00000001f; 
		bool y = Math.Abs (c.y) < 0.00000001f; 
		bool z = Math.Abs (c.z) < 0.00000001f; 
		return !(x && y && z);
	}
}

