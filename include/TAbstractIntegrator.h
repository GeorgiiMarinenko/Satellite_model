#ifndef TABSTRACTINTEGRATOR_H
#define TABSTRACTINTEGRATOR_H
#include "TDynamicModel.h"

class TAbstractIntegrator
{
public:
	TAbstractIntegrator(TDynamicModel *Model);
	~TAbstractIntegrator();

	TDynamicModel *Model;//Динамический полиморвифзм

	virtual TVector	OneStep() = 0;
	virtual TVector	MoveTo() = 0;


	double	start_time;
	double	end_time;
	double	step;
};

TAbstractIntegrator::TAbstractIntegrator(TDynamicModel *Model)
{
	this->Model = Model;
}

TAbstractIntegrator::~TAbstractIntegrator()
{}
#endif
