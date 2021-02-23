import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GenerateQuizzFormComponent } from './generate-quizz-form.component';

describe('GenerateQuizzFormComponent', () => {
  let component: GenerateQuizzFormComponent;
  let fixture: ComponentFixture<GenerateQuizzFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GenerateQuizzFormComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GenerateQuizzFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
