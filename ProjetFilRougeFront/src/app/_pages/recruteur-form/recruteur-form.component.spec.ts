import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RecruteurFormComponent } from './recruteur-form.component';

describe('RecruteurFormComponent', () => {
  let component: RecruteurFormComponent;
  let fixture: ComponentFixture<RecruteurFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RecruteurFormComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RecruteurFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
