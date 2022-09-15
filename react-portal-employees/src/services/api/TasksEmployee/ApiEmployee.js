import Api from "../ApiAxios";

class apiEmployee{
    
    CreateEmployee = async (Employee) => {
        return new Promise((resolve, reject) => {
            Api.post('./Employee', Employee)
            .then((response) => response.data)
            .catch((error) => { reject(error);});
        });
    }
}
const ApiEmployee = new apiEmployee();
export default ApiEmployee;