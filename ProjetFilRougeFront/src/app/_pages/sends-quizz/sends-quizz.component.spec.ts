import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SendsQuizzComponent } from './sends-quizz.component';

describe('SendsQuizzComponent', () => {
  let component: SendsQuizzComponent;
  let fixture: ComponentFixture<SendsQuizzComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SendsQuizzComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SendsQuizzComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
