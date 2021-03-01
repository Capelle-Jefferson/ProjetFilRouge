import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DetailsQuizzFormComponent } from './details-quizz-form.component';

describe('DetailsQuizzFormComponent', () => {
  let component: DetailsQuizzFormComponent;
  let fixture: ComponentFixture<DetailsQuizzFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DetailsQuizzFormComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DetailsQuizzFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
