namespace CreditSuisseItDevRisk;

record Trade(double Value, string ClientSector, DateTime NextPaymentDate) : ITrade { }
