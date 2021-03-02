import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SendsQuizzFormComponent } from './sends-quizz-form.component';

describe('SendsQuizzFormComponent', () => {
  let component: SendsQuizzFormComponent;
  let fixture: ComponentFixture<SendsQuizzFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SendsQuizzFormComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SendsQuizzFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
