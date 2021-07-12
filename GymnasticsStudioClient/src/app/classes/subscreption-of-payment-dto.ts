import { StudentInSubscreptionDescriptionDTO } from "./student-in-subscreption-description-dto"

export class SubscreptionOfPaymentDTO {

    public  PaymentId:number
    public  Sum :number
    public  StartDate :string
    public  StudentInSubscreptionDescriptionList:Array<StudentInSubscreptionDescriptionDTO>

}
