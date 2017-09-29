export interface IReviewComment {
    CreditCardId: number;
    ReviewerComment: string;
    IsApproved?: boolean;
    IsPerformed?: boolean;
    IsRejected?: boolean;
}
