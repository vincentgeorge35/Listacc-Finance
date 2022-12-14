/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package model.display;

import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.Calendar;
import model.Clients;
import model.Incomes;
import model.Persons;
import services.data.ClientService;

/**
 *
 * @author Agozie
 */
public final class DisplayIncome extends Incomes{
    String serviceName;
    String clientName;
    String clientFirstName;
    int serviceIdnum;
    Clients  client;
    String displayPaymentType;
    String dateString;
    int paymentCounts;
    int parentIncomeId;

    public int getParentIncomeId() {
        return parentIncomeId;
    }

    public void setParentIncomeId(int parentIncomeId) {
        this.parentIncomeId = parentIncomeId;
    }

    public int getPaymentCounts() {
        return paymentCounts;
    }

    public void setPaymentCounts(int paymentCounts) {
        this.paymentCounts = paymentCounts;
    }
    public String getDateString() {
        Long date =   getDate();
        long dateLong = date;
        Calendar calendar = Calendar.getInstance();
        calendar.setTimeInMillis(dateLong);
        DateFormat df = new SimpleDateFormat("dd-EEE, MM, yyyy");
        return df.format(calendar.getTime());
    }
    
   
    
    public String getDateStringWithTime() {
        Long date =   getDate();
        long dateLong = date;
        Calendar calendar = Calendar.getInstance();
        calendar.setTimeInMillis(dateLong);
        DateFormat df = new SimpleDateFormat("HH:MM - dd-EEE, MM, yyyy");
        return df.format(calendar.getTime());
    }

    public void setDateString(String dateString) {
        this.dateString = dateString;
    }
    

    public String getDisplayPaymentType() {
        return displayPaymentType;
    }

    public void setDisplayPaymentType(String paymentType) {
        this.displayPaymentType = paymentType;
    }

    @Override
    public Clients getClient() {
        return  client == null? super.getClient(): client;
    }

    @Override
    public void setClient(Clients client) {
        this.client = client;
    }

    public Persons getPerson() {
        return this.person;
    }

    public void setPerson(Persons person) {
        this.person = person;
    }
    Persons person;

    public int getServiceIdnum() {
        return serviceIdnum;
    }

    public void setServiceIdnum(int serviceIdnum) {
        this.serviceIdnum = serviceIdnum;
    }

    public String getClientFirstName() {
        return clientFirstName;
    }

    public void setClientFirstName(String clientFirstName) {
        this.clientFirstName = clientFirstName;
    }

    public String getClientLastName() {
        return clientLastName;
    }

    public void setClientLastName(String clientLastName) {
        this.clientLastName = clientLastName;
    }
    String clientLastName;

    public String getServiceName() {
        return serviceName;
    }

    public void setServiceName(String serviceName) {
        this.serviceName = serviceName;
    }

    public String getClientName() {
        return clientName;
    }

    public void setClientName(String clientName) {
        this.clientName = clientName;
    }
    
    public DisplayIncome(){
        super();
    }
    int clientNumId;

    public int getClientNumId() {
        return clientNumId;
    }

    public void setClientNumId(int clientNumId) {
        this.clientNumId = clientNumId;
    }
    public DisplayIncome(String serviceName, String clientName, int clientId,   Integer id, Long date,int unit, double amountReceived, double discount, String paymentType, double amountReceivable, Long dateDue) {
        super(id, date,unit, amountReceived, discount, amountReceivable, dateDue);
        this.serviceName = serviceName;
        this.displayPaymentType = paymentType;
        Clients clien = new ClientService().getClientById(clientId);
                this.client = clien;
        if (null == clientName || clientName.isEmpty())
        {
            
            if(null != clien.getPerson())
             this.clientName = clien.getPerson().getLastName() + " " + clien.getPerson().getFirstName();
            else 
                this.clientName = clien.getBusinessName();
           this.clientNumId = clien.getId();
        }
        else {
            this.clientName = clientName;
        }
            
    }
    
    public DisplayIncome(String serviceName, String clientName, Integer clientId,   Integer id, Long date,Integer unit, Double amountReceived, Double discount, String paymentType, Double amountReceivable, Long dateDue, Integer count) {
        super(id, date,unit, amountReceived, discount, amountReceivable, dateDue);
        this.serviceName = serviceName;
        this.paymentCounts = count + 1;
        
        Clients clien = new ClientService().getClientById(clientId);
            setClient(clien);
        this.displayPaymentType = paymentType;
        if (null == clientName || clientName.isEmpty())
        { 
            
            if(null != clien.getPerson())
             this.clientName = clien.getPerson().getLastName() + " " + clien.getPerson().getFirstName();
            else 
                this.clientName = clien.getBusinessName();
           this.clientNumId = clien.getId();
        }
        else 
            this.clientName = clientName;
            
    }
    
            
}
