using System;

namespace eNumismat
{
    class Collection
    {
        string[] CollectionDetails;

        //=============================================================================================================
        public void SetCollectionDetails(String colName, String colDescription = null)
        {
            CollectionDetails[0] = colName;
            CollectionDetails[1] = colDescription;
        }

        //=============================================================================================================
        public String[] GetCollectionDetails()
        {
            return CollectionDetails;
        }
    }
}
