export class Payment {
    constructor(

        public Id:number,
        public Sum:number=0,
        public StudentId:number=0,
        public FormOfPayment:string,
        public StartDate:string,
        public FinishDate:string,

    ){}
}
