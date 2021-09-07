using RestaurantAnalyzer;

using System;
using System.Threading.Tasks;

var searcher = new GoogleSearcher();

await searcher.Search();