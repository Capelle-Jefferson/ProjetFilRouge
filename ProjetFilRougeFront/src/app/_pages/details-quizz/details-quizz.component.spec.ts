import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DetailsQuizzComponent } from './details-quizz.component';

describe('DetailsQuizzComponent', () => {
  let component: DetailsQuizzComponent;
  let fixture: ComponentFixture<DetailsQuizzComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DetailsQuizzComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DetailsQuizzComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
