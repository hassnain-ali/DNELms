export function IsActiveDDL(): IsActiveVM[] {
    return [{ Value: true, Text: 'Yes!' }, { Value: false, Text: 'No!' }];
}
export interface IsActiveVM {
    Value: any,
    Text: string
}