import { FileInput } from "ngx-material-file-input";

export interface Category {
    Id: number,
    IsActive: boolean,
    Name: string,
    BannerImage: FileInput,
    SmallImage: FileInput,
    ParentId: number
}