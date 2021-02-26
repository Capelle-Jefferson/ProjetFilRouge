import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ConnexionQuizzComponent } from './connexion-quizz.component';

describe('ConnexionQuizzComponent', () => {
  let component: ConnexionQuizzComponent;
  let fixture: ComponentFixture<ConnexionQuizzComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ConnexionQuizzComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ConnexionQuizzComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
