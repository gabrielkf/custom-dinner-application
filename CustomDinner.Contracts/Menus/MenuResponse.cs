namespace Contracts.Menus;

public record MenuResponse(
    Guid Id,
    string Name,
    string Description,
    List<MenuSectionResponse> Sections,
    string HostId,
    List<string> DinnerIds,
    List<string> MenuReviewIds,
    DateTime CreatedDateTime,
    DateTime UpdatedDateTime);
    
public record MenuSectionResponse(
    Guid Id,
    string Name,
    string Description,
    List<MenuItemResponse> MenuItemResponse);
    
public record MenuItemResponse(
    Guid Id,
    string Name,
    string Description);