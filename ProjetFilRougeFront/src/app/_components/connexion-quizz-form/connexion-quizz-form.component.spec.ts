import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ConnexionQuizzFormComponent } from './connexion-quizz-form.component';

describe('ConnexionQuizzFormComponent', () => {
  let component: ConnexionQuizzFormComponent;
  let fixture: ComponentFixture<ConnexionQuizzFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ConnexionQuizzFormComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ConnexionQuizzFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
