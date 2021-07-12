export class Lesson {
    
        public Id:number;
        public Name:string;
        public TeacherId:number;     
        public Day:string; 
        public StartHower:string;
        public FinishHower:string;
        public MaxStudensNum:number;
        public MaxSerologersStudensNum:number;
        public LessonKind:number;

        constructor(init?: Partial<Lesson>) {
                Object.assign(this, init);
            }
        
}
