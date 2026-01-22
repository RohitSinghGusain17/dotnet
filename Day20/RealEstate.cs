public interface IRealEstateListing
{
    int ID{get; set;}
    string? Title{get; set;}
    string? Description{get; set;}
    int Price{get; set;}
    string? Location{get; set;}
}
public class RealEstateListing : IRealEstateListing
{
    public int ID{get; set;}
    public string? Title{get; set;}
    public string? Description{get; set;}
    public int Price{get; set;}
    public string? Location{get; set;}
}

public class RealEstateApp
{
    private List<IRealEstateListing> listings = new List<IRealEstateListing>();

    public void AddListing(IRealEstateListing listing)
    {
        listings.Add(listing);
    }

    public void RemoveListing(int listingID)
    {
        foreach(IRealEstateListing i in listings)
        {
            if (i.ID == listingID)
            {
                listings.Remove(i);
                Console.WriteLine($"ID {listingID} Removed Successfully");
                break;
            }
        }
    }

    public void UpdateListing(IRealEstateListing listing)
    {
        foreach(IRealEstateListing i in listings)
        {
            if (listing.ID == i.ID)
            {
                i.Title=listing.Title;
                i.Price=listing.Price;
                i.Description=listing.Description;
                i.Location=listing.Location;
                Console.WriteLine($"Id {listing.ID} Updated Successfully");
            }
        }
    }

    public List<IRealEstateListing> GetListings()
    {
        return listings;
    }

    public List<IRealEstateListing> GetListingsByLocation(string location)
    {
        List<IRealEstateListing> result = new List<IRealEstateListing>();
        foreach(IRealEstateListing i in listings)
        {
            if (i.Location == location)
            {
                result.Add(i);
            }
        }
        
        return result;
    }

    public List<IRealEstateListing> GetListingsByPriceRange(int minPrice, int maxPrice)
    {
        List<IRealEstateListing> result = new List<IRealEstateListing>();
        foreach(IRealEstateListing i in listings)
        {
            if(i.Price>=minPrice && i.Price <= maxPrice)
            {
                result.Add(i);
            }
        }

        return result;
    }
}