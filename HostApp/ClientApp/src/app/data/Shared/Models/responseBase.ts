

export class Message {
    systemMessage: string;
    messageType: number;
    messageCode: string;

    constructor(obj?: any) {
        this.systemMessage = obj && obj.systemMessage;
        this.messageType = obj && obj.messageType;
        this.messageCode = obj && obj.messageCode;
    }

}

export class ResponseBase {

    status: boolean;
    messages: Message[];

    constructor(obj?: any) {
        this.status = obj && obj.status;
        this.messages = obj && obj.messages || Array();
    }
}
