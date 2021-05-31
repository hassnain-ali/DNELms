import { FileInput } from "ngx-material-file-input";

export class Convert {
    static toBool(val: any): boolean {
        return JSON.parse(val);
    }
    static toFile(val: FileInput): File {
        try {
            return val.files[0];

        } catch (error) {
            return null;
        }
    }
    static toFiles(val: FileInput): File[] {
        return val.files;
    }
    static toFormData(object: any): FormData {
        const formData = new FormData();
        Object.keys(object).forEach(key => formData.append(key, object[key]));
        return formData;
    }
}