import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GeneratesQuizzesComponent } from './generates-quizzes.component';

describe('GeneratesQuizzesComponent', () => {
  let component: GeneratesQuizzesComponent;
  let fixture: ComponentFixture<GeneratesQuizzesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GeneratesQuizzesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GeneratesQuizzesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
