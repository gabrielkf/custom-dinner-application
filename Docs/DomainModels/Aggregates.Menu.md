# Domain Models

## Menu

```csharp
class Menu
{
    Menu Create();
    void AddDinner(Dinner dinner);
    void RemoveDinner(Dinner dinner);
    void UpdateSection(MenuSection, section);
}
```

```json
{
  "id": "00000000-0000-0000-0000-000000000000",
  "name": "Nice menu",
  "description": "Fancy food",
  "sections": [
    {
      "name": "Appetizers",
      "description": "Starters",
      "items": [
        {
          "name": "Fried Pickles",
          "description": "Deep fried pickles",
          "price": 69.42
        },
        {
          "name": "Fried Pickles",
          "description": "Deep fried pickles",
          "price": 69.42
        }
      ]
    },
    {
      "name": "Barbecue",
      "description": "Main course",
      "items": [
        {
          "name": "Tenderloin",
          "description": "1st grade meat",
          "price": 128.04
        }
      ]
    },
    {
      "name": "Petit gateau",
      "description": "Dessert",
      "items": [
        {
          "name": "Brownie",
          "description": "Made with belgian chocolate",
          "price": 18.04
        },
        {
          "name": "Ice cream",
          "description": "Italian",
          "price": 12.04
        }
      ]
    }
  ],
  "averageRating": {
      "value": 4.4,
      "numRatings": 42
  },
  "createdDateTime": "2023-08-20 15:30:00",
  "updatedDateTime": "2023-08-20 15:30:00",
  "hostId": "00000000-0000-0000-0000-000000000000",
  "dinnerIds": [
    "00000000-0000-0000-0000-000000000000"
  ],
  "menuReviewIds": [
    "00000000-0000-0000-0000-000000000000"
  ]
}
```

# REST endpoint
`POST /host/{hostId}/menus`