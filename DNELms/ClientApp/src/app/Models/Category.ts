
export interface Category {
    Id: number,
    IsActive: Boolean,
    Name: string,
    BannerImage: File,
    SmallImage: File,
    ParentId: number
}
export interface CategoryVM {
    Id: number,
    IsActive: Boolean,
    Name: string,
    ParentId: number
}