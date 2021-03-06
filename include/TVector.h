#include <math.h>
# define W 39860300000

struct	TVector
{
	double	x0;
	double	x1;
	double	x2;
	double	x3;
	double	x4;
	double	x5;
};

TVector operator * (TVector vec, double value)
{
	vec.x0 *= value;
	vec.x1 *= value;
	vec.x2 *= value;
	vec.x3 *= value;
	vec.x4 *= value;
	vec.x5 *= value;

	return (vec);
}

TVector operator + (TVector vec1, TVector vec2)
{
	vec1.x0 += vec2.x0;
	vec1.x1 += vec2.x1;
	vec1.x2 += vec2.x2;
	vec1.x3 += vec2.x3;
	vec1.x4 += vec2.x4;
	vec1.x5 += vec2.x5;

	return (vec1);
}
