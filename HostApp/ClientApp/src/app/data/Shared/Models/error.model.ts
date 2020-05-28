

export class Error {
    constructor(obj?: any) {
        this.error = obj && obj.error || "";
    }
    error: string;
}