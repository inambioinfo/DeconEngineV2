#pragma once
#include <vector>
#include <map>

namespace Engine
{
	namespace HornTransform
	{
		const double ELECTRON_MASS = 0.00054858;
		class  MercuryCache
		{
			int mint_last_used_cache_position ; 
			int mint_num_distributions ; 
			int mint_isotope_processing_time ; 


			double mdbl_start_mz ; 
			double mdbl_stop_mz ; 

#pragma warning(disable:4251)
			std::multimap<int, int> mmap_isotope_dist_vals_cached ; 
			std::vector<double> mvect_isotope_dist_vals ; 
			std::vector<double>mvect_temp_peak_mz ; 
			std::vector<double>mvect_temp_peak_intensity ; 
			std::vector<int> mvect_indices ; 
			std::vector<int> mvect_entity_elements ;
#pragma warning(default:4251)
			inline GetIsotopeDistributionCachedAtPosition(int position, short charge, double FWHM, double min_theoretical_intensity, std::vector<double>&mzs, std::vector<double>&intensities) ;
			double mdbl_cc_mass ; 
			int mint_max_profile_size ; 

		public:

			double mdbl_max_peak_mz ; 
			double mdbl_average_mw ; 
			double mdbl_mono_mw ; 
			double mdbl_most_intense_mw ; 

			MercuryCache(void);
			~MercuryCache(void);
			void SetOptions(double cc_mass, int max_size) ; 
			bool GetIsotopeDistributionCached(double observed_most_abundant_mass, short charge, double FWHM, double min_theoretical_intensity, std::vector<double>&mzs, std::vector<double>&intensities) ;
			// the observed most abundance mass is what the map will be created from. This comes from the spectrum.
			// the most abundant mass, etc comes from the values generated by mercury. 
			void CacheIsotopeDistribution(double observed_most_abundant_mass, double most_abundant_mass, double mono_mass, double average_mass, double most_abundant_mz, short charge, double FWHM, int num_pts_per_amu, double min_intensity, std::vector<double>&mzs, std::vector<double>&intensities) ;
			void FindPeak(double start_mz, double end_mz, double &mz, double &intensity) ; 
		};

}
}