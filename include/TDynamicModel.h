#ifndef TDYNAMICMODEL_H
#define TDYNAMICMODEL_H
#include "TVector.h"

class TDynamicModel
{
protected:
	TVector vector;
public:
	TDynamicModel();
	~TDynamicModel();

	virtual TVector	RightParts() = 0;
	void	SetVector(TVector vector);
	TVector	GetVector();
};

TDynamicModel::TDynamicModel()
{}

TDynamicModel::~TDynamicModel()
{}

void TDynamicModel::SetVector(TVector vector)
{
	this->vector = vector;
}

TVector TDynamicModel::GetVector()
{
	return (vector);
}

#endif
