export interface ISendMessageDto{
    receiverUserName:string;
    text:string;
}

export interface ImessageDto extends ISendMessageDto{
    id:number;
    senderUserName:string;
    createAt:string;
}