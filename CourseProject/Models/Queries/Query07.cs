namespace CourseProject.Models.Queries;

public record Query07(
    int Id,
    string InsuranceType,
    int InsurancePrice,
    int Tariff,
    DateTime ContractDate,
    int ContractCount,
    int TotalSum
);
