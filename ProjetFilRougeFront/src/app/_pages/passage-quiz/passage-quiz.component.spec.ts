import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PassageQuizComponent } from './passage-quiz.component';

describe('PassageQuizComponent', () => {
  let component: PassageQuizComponent;
  let fixture: ComponentFixture<PassageQuizComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PassageQuizComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PassageQuizComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
