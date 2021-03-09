import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { User } from 'src/app/_models/user';
import { UserService } from 'src/app/_services/user.service';

@Component({
  selector: 'app-recruteurs',
  templateUrl: './recruteurs.component.html',
  styleUrls: ['./recruteurs.component.css']
})
export class RecruteursComponent implements OnInit {

  users : User[];
  deleteIcon = "../assets/images/icons/trash.svg";
  msgError = "";

  constructor(
    private userService : UserService,
    private router:Router,
    private toastr: ToastrService
  ) { }

  async ngOnInit() {
    await this.userService.getAllRecruteur().then(data => this.users = data);
  }

  async deleteUser(user){
    let res = true;
    await this.userService.delete(user.idUser).catch(data => res = false );
    if(res){
      this.toastr.success("Le recruteur à bien était supprimé");
      this.router.navigateByUrl('/RecruteursComponent', { skipLocationChange: true}).then(() => {
        this.router.navigate(["/recruteurs"]);
      })
    }else{
      this.toastr.error("Ce recruteur ne peut pas être supprimé");
      this.msgError = "Ce recruteur ne peut pas être supprimé, il est associé à un ou plusieurs candidats ! ";
    }
  }
}
