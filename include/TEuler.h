#ifndef TEULER_H
#define TEULER_H
#include "TAbstractIntegrator.h"

class TEuler:public TAbstractIntegrator
{
private:
	/* data */
public:
	TEuler(TDynamicModel *Model);
	~TEuler();

	TVector	OneStep();
	TVector	MoveTo();
};

TEuler::TEuler(TDynamicModel *Model) : TAbstractIntegrator(Model)
{
}

TEuler::~TEuler()
{
}

TVector TEuler::OneStep()
{
	TVector NewVec;
	NewVec = Model->GetVector() + Model->RightParts()*step;
	Model->SetVector(NewVec);

	return (NewVec);
}

TVector TEuler::MoveTo()
{
	TVector vec;
	return (vec);
}
#endif
