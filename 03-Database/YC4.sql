SET SERVEROUTPUT ON

GRANT CREATE JOB TO admin1;
GRANT CREATE EXTERNAL JOB TO admin1;
GRANT CREATE CREDENTIAL TO admin1;

conn admin1/123;

BEGIN
    DBMS_CREDENTIAL.create_credential(
        credential_name => 'admin1_CREDENTIAL',
        -- username và password của localhost trên máy mình
        username => 'trung',
        password => '3004T2003t'
    );
END;
/

--begin
--    DBMS_CREDENTIAL.drop_credential(
--        credential_name => 'admin1_CREDENTIAL'
--        );
--
--end;
--/

begin 
    DBMS_SCHEDULER.CREATE_SCHEDULE(
        schedule_name=> 'Full_backup_schedule',
        start_date=> systimestamp,
        repeat_interval=> 'FREQ=WEEKLY; 
                        BYDAY=SUN; BYHOUR=0;
                        BYMINUTE=0; BYSECOND=0',
        end_date=> null,
        comments => 'Full back up once a week at 0PM in sunday'
    );    
end;
/
begin
    DBMS_SCHEDULER.CREATE_PROGRAM(
        program_name => 'FULL_BACKUP_PROGRAM',
        program_type => 'BACKUP_SCRIPT',
        program_action => q'[connect target /
            RUN {
                BACKUP INCREMENTAL LEVEL 0 DATABASE;
            }]',
        enabled  => TRUE
    );
end;
/
BEGIN
    DBMS_SCHEDULER.create_job (
    job_name => 'FULL_BACKUP_JOB',
    program_name => 'FULL_BACKUP_PROGRAM',
    schedule_name => 'FULL_BACKUP_SCHEDULE',
    credential_name => 'admin1_CREDENTIAL',
    enabled => TRUE
    );
end;
/


begin 
    DBMS_SCHEDULER.CREATE_SCHEDULE(
        schedule_name=> 'INCREDENTIAL_BACKUP_SCHEDULE',
        start_date=> systimestamp,
        repeat_interval=>   'FREQ=WEEKLY;
                            BYDAY=MON,TUE,WED,THU,FRI,SAT; 
                            BYHOUR=0; 
                            BYMINUTE=0;
                            BYSECOND=0',
        end_date=> null,
        comments => 'Incredential backup at 0 o''clock in weekdays'
    );    
end;
/


begin 
    DBMS_SCHEDULER.CREATE_PROGRAM(
        program_name => 'INCREDENTIAL_BACKUP_PROGRAM',
        program_type => 'BACKUP_SCRIPT',
        program_action => q'[connect target /
                RUN {
                    BACKUP INCREMENTAL LEVEL 1 DATABASE;
                }]',
        enabled  => TRUE
    );
end;
/
begin
    DBMS_SCHEDULER.create_job (
    job_name => 'INCREMENTAL_BACKUP_JOB',
    program_name => 'INCREDENTIAL_BACKUP_PROGRAM',
    
    schedule_name =>   'INCREDENTIAL_BACKUP_SCHEDULE',
    credential_name => 'admin1_CREDENTIAL',
    enabled => TRUE
    );
END;
/

--execute DBMS_SCHEDULER.drop_job('FULL_BACKUP_JOB');
--execute DBMS_SCHEDULER.drop_schedule('FULL_BACKUP_SCHEDULE');
--execute dbms_scheduler.drop_program('FULL_BACKUP_PROGRAM');
--
--execute DBMS_SCHEDULER.drop_job('INCREMENTAL_BACKUP_JOB');
--execute DBMS_SCHEDULER.drop_schedule('INCREDENTIAL_BACKUP_SCHEDULE');
--execute dbms_scheduler.drop_program('INCREDENTIAL_BACKUP_PROGRAM');

 SELECT JOB_NAME, STATE, REPEAT_INTERVAL, NEXT_RUN_DATE
 FROM USER_SCHEDULER_JOBS where job_name like '%BACKUP%';
 SELECT *
 FROM USER_SCHEDULER_JOBS
 WHERE JOB_NAME = 'INCREMENTAL_BACKUP_JOB';

 SELECT *
 FROM USER_SCHEDULER_PROGRAMS;

 select * FROM   dba_scheduler_job_run_details where job_name like '%BACKUP%';



