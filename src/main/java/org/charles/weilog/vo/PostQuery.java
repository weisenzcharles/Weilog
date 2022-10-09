package org.charles.weilog.vo;

import lombok.Data;

@Data
public class PostQuery {

    private String title;
    private Long taxonomyId;
    private boolean recommend;
}