import { IAttachments } from "./attachments";

export interface IUserProfile {   
    UserName: string;
    ProfileName: string;
    ProfileImage?: string;
    userProfileId?: number;
    Attachments?: IAttachments[];
}
