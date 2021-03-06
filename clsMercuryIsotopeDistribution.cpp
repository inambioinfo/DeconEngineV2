// Written by Navdeep Jaitly for the Department of Energy (PNNL, Richland, WA)
// Copyright 2006, Battelle Memorial Institute
// E-mail: navdeep.jaitly@pnl.gov
// Website: http://ncrr.pnl.gov/software
// -------------------------------------------------------------------------------
// 
// Licensed under the Apache License, Version 2.0; you may not use this file except
// in compliance with the License.  You may obtain a copy of the License at 
// http://www.apache.org/licenses/LICENSE-2.0

#pragma once
#include "clsMercuryIsotopeDistribution.h"
#include "DeconEngineUtils.h"

namespace DeconToolsV2
{
	clsMercuryIsotopeDistribution::clsMercuryIsotopeDistribution()
	{
		mMercuryIsotopeDistribution = new Engine::TheoreticalProfile::MercuryIsotopeDistribution();
		set_MercurySize(8192);
		set_ChargeCarrierMass(1.007824659); 
		set_ApodizationType(ApodizationType::Gaussian);
		set_Resolution(100000);
		set_ChargeState(1);
	}

	clsMercuryIsotopeDistribution::~clsMercuryIsotopeDistribution()
	{
		if (mMercuryIsotopeDistribution != NULL)
		{
			delete mMercuryIsotopeDistribution;
			mMercuryIsotopeDistribution = NULL ; 
		}
	}


	System::Drawing::PointF clsMercuryIsotopeDistribution::CalculateDistribution(System::Collections::Hashtable* elementCounts)[]
	{
		std::vector<double> vect_x;
		std::vector<double> vect_y;

		std::vector<double> vect_isotope_x;
		std::vector<double> vect_isotope_y;

		System::Drawing::PointF points __gc [];

		Engine::TheoreticalProfile::MolecularFormula formula ; 
		DeconEngine::Utils::ConvertElementTableToFormula(mMercuryIsotopeDistribution->mobj_elemental_isotope_composition, elementCounts, formula);

		mMercuryIsotopeDistribution->CalculateDistribution(mChargeState, mResolution, formula, vect_x, vect_y, 0, vect_isotope_x, vect_isotope_y, false);

		int num_pts = (int) vect_x.size();
		points = new System::Drawing::PointF __gc [num_pts] ;

		for (int i = 0 ; i < num_pts ; i++)
		{
			points[i] = System::Drawing::PointF((float) vect_x[i], (float) vect_y[i]);
		}

		return points;
	};

	void clsMercuryIsotopeDistribution::CalculateMasses(System::Collections::Hashtable* elementCounts) 
	{		
		Engine::TheoreticalProfile::MolecularFormula formula ; 
		DeconEngine::Utils::ConvertElementTableToFormula(mMercuryIsotopeDistribution->mobj_elemental_isotope_composition, elementCounts, formula);

		mMercuryIsotopeDistribution->CalculateMasses(formula);
	}
}