import { IAttachments } from "./attachments";

export interface ICreditCard {
    CreditCardId: number;
    FullName: string;
    DisplayName: string;
    Nic: string;
    Passport: string;
    Address: string;
    MobilePhone: string;
    HomePhone: string;
    OfficePhone: string;
    Email: string;
    Employer: string;
    Salary: number;
    JobTitle: string;
    //CreditCardNumber: string;
    //BillingDate: string;
    //CardExpiryDate: string;
    //Cvv: string;
    CardLimit: number;
    CashLimit: number;
    //RequestedBy: string;
    Note: string;
    CardTypeId: number;
    CardTypeName?: string;

    NationalityId: number;
    NationalityName?: string;
    CardStatusId?: number;
    CardStatusName?: string;
    ReviewerComment?: string;
    Attachments?: IAttachments[];
}