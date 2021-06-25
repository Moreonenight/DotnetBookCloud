// ATLTemp.cpp: CATLTemp 的实现

#include "pch.h"
#include "ATLTemp.h"


// CATLTemp

STDMETHODIMP CATLTemp::Multiplier(DOUBLE __num1, DOUBLE __num2, DOUBLE* __result)
{
	*__result = __num1 * __num2;
	return S_OK;
}