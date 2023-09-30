# Domain Models
## Dinner

```csharp
class Dinner
{
    public static Dinner Create();
    void AddReservation(DinnerReservation reservation);
    void RemoveReservation(Reservation dinner);
}

record struct DinnerReservation[](DinnerId, GuestId, BillId)
    
```

```json
{
  "id": "00000000-0000-0000-0000-000000000000",
  "name": "Very dinner",
  "description": "Such tasty",
  "createdDateTime": "2023-08-20 15:30:00",
  "updatedDateTime": "2023-08-20 15:30:00",
  "hostId": "00000000-0000-0000-0000-000000000000",
  "menuId": "00000000-0000-0000-0000-000000000000",
  "reservations": [
    {
      "dinnerId": "00000000-0000-0000-0000-000000000000", 
      "guestId": "00000000-0000-0000-0000-000000000000",
      "billId": "00000000-0000-0000-0000-000000000000"
    },
    {}
  ]
}
```