using System;
using System.Collections.Generic;
using FlaxEngine;

namespace FTween
{
	public enum Ease
	{
		QuadraticEaseOut,
		QuadraticEaseIn,
		QuadraticEaseInOut,
		CubicEaseIn,
		CubicEaseOut,
		CubicEaseInOut,
		QuarticEaseIn,
		QuarticEaseOut,
		QuarticEaseInOut,
		QuinticEaseIn,
		QuinticEaseOut,
		QuinticEaseInOut,
		SineEaseIn,
		SineEaseOut,
		SineEaseInOut,
		CircularEaseIn,
		CircularEaseOut,
		CircularEaseInOut,
		ExponentialEaseIn,
		ExponentialEaseOut,
		ExponentialEaseInOut,
		ElasticEaseIn,
		ElasticEaseOut,
		ElasticEaseInOut,
		BackEaseIn,
		BackEaseOut,
		BackEaseInOut,
		BounceEaseIn,
		BounceEaseOut,
		BounceEaseInOut,
		Linear,
	}
	public class EaseFunc : Script
	{
		/// <summary>
		/// Constant Pi.
		/// </summary>
		private const float PI = (float)Math.PI;

		/// <summary>
		/// Constant Pi / 2.
		/// </summary>
		private const float HALFPI = (float)Math.PI / 2.0f;

		/// <summary>
		/// Easing Functions enumeration
		/// </summary>

		/// <summary>
		/// Interpolate using the specified function.
		/// </summary>
		static public float Evaluate(float p, Ease function)
		{
			switch (function)
			{
				default:
				case Ease.QuadraticEaseOut: return QuadraticEaseOut(p);
				case Ease.QuadraticEaseIn: return QuadraticEaseIn(p);
				case Ease.QuadraticEaseInOut: return QuadraticEaseInOut(p);
				case Ease.CubicEaseIn: return CubicEaseIn(p);
				case Ease.CubicEaseOut: return CubicEaseOut(p);
				case Ease.CubicEaseInOut: return CubicEaseInOut(p);
				case Ease.QuarticEaseIn: return QuarticEaseIn(p);
				case Ease.QuarticEaseOut: return QuarticEaseOut(p);
				case Ease.QuarticEaseInOut: return QuarticEaseInOut(p);
				case Ease.QuinticEaseIn: return QuinticEaseIn(p);
				case Ease.QuinticEaseOut: return QuinticEaseOut(p);
				case Ease.QuinticEaseInOut: return QuinticEaseInOut(p);
				case Ease.SineEaseIn: return SineEaseIn(p);
				case Ease.SineEaseOut: return SineEaseOut(p);
				case Ease.SineEaseInOut: return SineEaseInOut(p);
				case Ease.CircularEaseIn: return CircularEaseIn(p);
				case Ease.CircularEaseOut: return CircularEaseOut(p);
				case Ease.CircularEaseInOut: return CircularEaseInOut(p);
				case Ease.ExponentialEaseIn: return ExponentialEaseIn(p);
				case Ease.ExponentialEaseOut: return ExponentialEaseOut(p);
				case Ease.ExponentialEaseInOut: return ExponentialEaseInOut(p);
				case Ease.ElasticEaseIn: return ElasticEaseIn(p);
				case Ease.ElasticEaseOut: return ElasticEaseOut(p);
				case Ease.ElasticEaseInOut: return ElasticEaseInOut(p);
				case Ease.BackEaseIn: return BackEaseIn(p);
				case Ease.BackEaseOut: return BackEaseOut(p);
				case Ease.BackEaseInOut: return BackEaseInOut(p);
				case Ease.BounceEaseIn: return BounceEaseIn(p);
				case Ease.BounceEaseOut: return BounceEaseOut(p);
				case Ease.BounceEaseInOut: return BounceEaseInOut(p);
				case Ease.Linear: return Linear(p);
			}
		}

		/// <summary>
		/// Modeled after the line y = x
		/// </summary>
		static public float Linear(float p)
		{
			return p;
		}

		/// <summary>
		/// Modeled after the parabola y = x^2
		/// </summary>
		static public float QuadraticEaseIn(float p)
		{
			return p * p;
		}

		/// <summary>
		/// Modeled after the parabola y = -x^2 + 2x
		/// </summary>
		static public float QuadraticEaseOut(float p)
		{
			return -(p * (p - 2));
		}

		/// <summary>
		/// Modeled after the piecewise quadratic
		/// y = (1/2)((2x)^2)             ; [0, 0.5)
		/// y = -(1/2)((2x-1)*(2x-3) - 1) ; [0.5, 1]
		/// </summary>
		static public float QuadraticEaseInOut(float p)
		{
			if (p < 0.5f)
			{
				return 2 * p * p;
			}
			else
			{
				return (-2 * p * p) + (4 * p) - 1;
			}
		}

		/// <summary>
		/// Modeled after the cubic y = x^3
		/// </summary>
		static public float CubicEaseIn(float p)
		{
			return p * p * p;
		}

		/// <summary>
		/// Modeled after the cubic y = (x - 1)^3 + 1
		/// </summary>
		static public float CubicEaseOut(float p)
		{
			float f = (p - 1);
			return f * f * f + 1;
		}

		/// <summary>	
		/// Modeled after the piecewise cubic
		/// y = (1/2)((2x)^3)       ; [0, 0.5)
		/// y = (1/2)((2x-2)^3 + 2) ; [0.5, 1]
		/// </summary>
		static public float CubicEaseInOut(float p)
		{
			if (p < 0.5f)
			{
				return 4 * p * p * p;
			}
			else
			{
				float f = ((2 * p) - 2);
				return 0.5f * f * f * f + 1;
			}
		}

		/// <summary>
		/// Modeled after the quartic x^4
		/// </summary>
		static public float QuarticEaseIn(float p)
		{
			return p * p * p * p;
		}

		/// <summary>
		/// Modeled after the quartic y = 1 - (x - 1)^4
		/// </summary>
		static public float QuarticEaseOut(float p)
		{
			float f = (p - 1);
			return f * f * f * (1 - p) + 1;
		}

		/// <summary>
		// Modeled after the piecewise quartic
		// y = (1/2)((2x)^4)        ; [0, 0.5)
		// y = -(1/2)((2x-2)^4 - 2) ; [0.5, 1]
		/// </summary>
		static public float QuarticEaseInOut(float p)
		{
			if (p < 0.5f)
			{
				return 8 * p * p * p * p;
			}
			else
			{
				float f = (p - 1);
				return -8 * f * f * f * f + 1;
			}
		}

		/// <summary>
		/// Modeled after the quintic y = x^5
		/// </summary>
		static public float QuinticEaseIn(float p)
		{
			return p * p * p * p * p;
		}

		/// <summary>
		/// Modeled after the quintic y = (x - 1)^5 + 1
		/// </summary>
		static public float QuinticEaseOut(float p)
		{
			float f = (p - 1);
			return f * f * f * f * f + 1;
		}

		/// <summary>
		/// Modeled after the piecewise quintic
		/// y = (1/2)((2x)^5)       ; [0, 0.5)
		/// y = (1/2)((2x-2)^5 + 2) ; [0.5, 1]
		/// </summary>
		static public float QuinticEaseInOut(float p)
		{
			if (p < 0.5f)
			{
				return 16 * p * p * p * p * p;
			}
			else
			{
				float f = ((2 * p) - 2);
				return 0.5f * f * f * f * f * f + 1;
			}
		}

		/// <summary>
		/// Modeled after quarter-cycle of sine wave
		/// </summary>
		static public float SineEaseIn(float p)
		{
			return (float)Math.Sin((p - 1) * HALFPI) + 1;
		}

		/// <summary>
		/// Modeled after quarter-cycle of sine wave (different phase)
		/// </summary>
		static public float SineEaseOut(float p)
		{
			return (float)Math.Sin(p * HALFPI);
		}

		/// <summary>
		/// Modeled after half sine wave
		/// </summary>
		static public float SineEaseInOut(float p)
		{
			return 0.5f * (1 - (float)Math.Cos(p * PI));
		}

		/// <summary>
		/// Modeled after shifted quadrant IV of unit circle
		/// </summary>
		static public float CircularEaseIn(float p)
		{
			return 1 - (float)Math.Sqrt(1 - (p * p));
		}

		/// <summary>
		/// Modeled after shifted quadrant II of unit circle
		/// </summary>
		static public float CircularEaseOut(float p)
		{
			return (float)Math.Sqrt((2 - p) * p);
		}

		/// <summary>	
		/// Modeled after the piecewise circular function
		/// y = (1/2)(1 - Math.Sqrt(1 - 4x^2))           ; [0, 0.5)
		/// y = (1/2)(Math.Sqrt(-(2x - 3)*(2x - 1)) + 1) ; [0.5, 1]
		/// </summary>
		static public float CircularEaseInOut(float p)
		{
			if (p < 0.5f)
			{
				return 0.5f * (1 - (float)Math.Sqrt(1 - 4 * (p * p)));
			}
			else
			{
				return 0.5f * ((float)Math.Sqrt(-((2 * p) - 3) * ((2 * p) - 1)) + 1);
			}
		}

		/// <summary>
		/// Modeled after the exponential function y = 2^(10(x - 1))
		/// </summary>
		static public float ExponentialEaseIn(float p)
		{
			return (p == 0.0f) ? p : (float)Math.Pow(2, 10 * (p - 1));
		}

		/// <summary>
		/// Modeled after the exponential function y = -2^(-10x) + 1
		/// </summary>
		static public float ExponentialEaseOut(float p)
		{
			return (p == 1.0f) ? p : 1 - (float)Math.Pow(2, -10 * p);
		}

		/// <summary>
		/// Modeled after the piecewise exponential
		/// y = (1/2)2^(10(2x - 1))         ; [0,0.5)
		/// y = -(1/2)*2^(-10(2x - 1))) + 1 ; [0.5,1]
		/// </summary>
		static public float ExponentialEaseInOut(float p)
		{
			if (p == 0.0 || p == 1.0) return p;

			if (p < 0.5f)
			{
				return 0.5f * (float)Math.Pow(2, (20 * p) - 10);
			}
			else
			{
				return -0.5f * (float)Math.Pow(2, (-20 * p) + 10) + 1;
			}
		}

		/// <summary>
		/// Modeled after the damped sine wave y = sin(13pi/2*x)*Math.Pow(2, 10 * (x - 1))
		/// </summary>
		static public float ElasticEaseIn(float p)
		{
			return (float)Math.Sin(13 * HALFPI * p) * (float)Math.Pow(2, 10 * (p - 1));
		}

		/// <summary>
		/// Modeled after the damped sine wave y = sin(-13pi/2*(x + 1))*Math.Pow(2, -10x) + 1
		/// </summary>
		static public float ElasticEaseOut(float p)
		{
			return (float)Math.Sin(-13 * HALFPI * (p + 1)) * (float)Math.Pow(2, -10 * p) + 1;
		}

		/// <summary>
		/// Modeled after the piecewise exponentially-damped sine wave:
		/// y = (1/2)*sin(13pi/2*(2*x))*Math.Pow(2, 10 * ((2*x) - 1))      ; [0,0.5)
		/// y = (1/2)*(sin(-13pi/2*((2x-1)+1))*Math.Pow(2,-10(2*x-1)) + 2) ; [0.5, 1]
		/// </summary>
		static public float ElasticEaseInOut(float p)
		{
			if (p < 0.5f)
			{
				return 0.5f * (float)Math.Sin(13 * HALFPI * (2 * p)) * (float)Math.Pow(2, 10 * ((2 * p) - 1));
			}
			else
			{
				return 0.5f * ((float)Math.Sin(-13 * HALFPI * ((2 * p - 1) + 1)) * (float)Math.Pow(2, -10 * (2 * p - 1)) + 2);
			}
		}

		/// <summary>
		/// Modeled after the overshooting cubic y = x^3-x*sin(x*pi)
		/// </summary>
		static public float BackEaseIn(float p)
		{
			return p * p * p - p * (float)Math.Sin(p * PI);
		}

		/// <summary>
		/// Modeled after overshooting cubic y = 1-((1-x)^3-(1-x)*sin((1-x)*pi))
		/// </summary>	
		static public float BackEaseOut(float p)
		{
			float f = (1 - p);
			return 1 - (f * f * f - f * (float)Math.Sin(f * PI));
		}

		/// <summary>
		/// Modeled after the piecewise overshooting cubic function:
		/// y = (1/2)*((2x)^3-(2x)*sin(2*x*pi))           ; [0, 0.5)
		/// y = (1/2)*(1-((1-x)^3-(1-x)*sin((1-x)*pi))+1) ; [0.5, 1]
		/// </summary>
		static public float BackEaseInOut(float p)
		{
			if (p < 0.5f)
			{
				float f = 2 * p;
				return 0.5f * (f * f * f - f * (float)Math.Sin(f * PI));
			}
			else
			{
				float f = (1 - (2 * p - 1));
				return 0.5f * (1 - (f * f * f - f * (float)Math.Sin(f * PI))) + 0.5f;
			}
		}

		/// <summary>
		/// </summary>
		static public float BounceEaseIn(float p)
		{
			return 1 - BounceEaseOut(1 - p);
		}

		/// <summary>
		/// </summary>
		static public float BounceEaseOut(float p)
		{
			if (p < 4 / 11.0f)
			{
				return (121 * p * p) / 16.0f;
			}
			else if (p < 8 / 11.0f)
			{
				return (363 / 40.0f * p * p) - (99 / 10.0f * p) + 17 / 5.0f;
			}
			else if (p < 9 / 10.0f)
			{
				return (4356 / 361.0f * p * p) - (35442 / 1805.0f * p) + 16061 / 1805.0f;
			}
			else
			{
				return (54 / 5.0f * p * p) - (513 / 25.0f * p) + 268 / 25.0f;
			}
		}

		/// <summary>
		/// </summary>
		static public float BounceEaseInOut(float p)
		{
			if (p < 0.5f)
			{
				return 0.5f * BounceEaseIn(p * 2);
			}
			else
			{
				return 0.5f * BounceEaseOut(p * 2 - 1) + 0.5f;
			}
		}
	}
}
