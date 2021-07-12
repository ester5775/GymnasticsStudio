import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpLoadFilesComponent } from './up-load-files.component';

describe('UpLoadFilesComponent', () => {
  let component: UpLoadFilesComponent;
  let fixture: ComponentFixture<UpLoadFilesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UpLoadFilesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UpLoadFilesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
