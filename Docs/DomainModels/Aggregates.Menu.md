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
  "description": "A really nice menu",
  "averageRating": 4.4,
  "sections": [
    {
      "id": "00000000-0000-0000-0000-000000000000",
      "name": "Appetizers",
      "description": "Starters",
      "items": [
        {
          "id": "00000000-0000-0000-0000-000000000000",
          "name": "Fried Pickles",
          "description": "Deep fried pickles",
          "price": 4.20
        }
      ]
    }
  ],
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